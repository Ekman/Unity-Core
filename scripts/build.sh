#!/bin/bash

set -euo pipefail

unity_path="Unity"
output_path="./Builds"
project_path="."
version=""
platforms=""

project_name="Its Not the End of the World"

while getopts "u:o:d:v:p:" flag
do
    case "$flag" in
        u) unity_path="$OPTARG";;
        o) output_path="$OPTARG";;
        d) project_path="$OPTARG";;
        v) version="$OPTARG";;
        p) platforms="$OPTARG";;
    esac
done

if [[ -z "$version" ]]; then
    >&2 echo "You must pass -v (version)."
    exit 1
fi

if [[ -z "$platforms" ]]; then
    >&2 echo "You must pass -p (platforms)."
    exit 1
fi

export VERSION="$version"
echo "Version = $version"

output_path=$(realpath "$output_path")
export OUTPUT_PATH="$output_path"
echo "Output path = $output_path"

project_path=$(realpath "$project_path")
echo "Project path = $project_path"

read -r -a split_platforms <<<"$platforms"

echo "Running pre-build..."
time "$unity_path" \
    -executeMethod "Nekman.Core.Editor.PreBuild.Run" \
    -quit \
    -batchmode \
    -silent-crashes \
    -logfile "$output_path/prebuild.log"

for platform in "${split_platforms[@]}"; do
    echo "Compiling \"$platform\"..."

    build_path="$output_path/$platform"
    log_path="$output_path/$platform.log"

    # See: https://docs.unity3d.com/Manual/EditorCommandLineArguments.html
    build_target="osxuniversal"
    case "$platform" in
        "Windows")
            build_target="win64"
            ;;
        "WebGl")
            build_target="webgl"
            ;;
        "Linux")
            build_target="linux64"
            ;;
    esac

    echo "Platform \"$platform\" equals build target \"$build_target\"."

    time "$unity_path" \
        -executeMethod "Nekman.Core.Editor.Build.$platform" \
        -quit \
        -batchmode \
        -silent-crashes \
        -projectPath "$project_path" \
        -logfile "$log_path" \
        -releaseCodeOptimization \
        -buildTarget "$build_target"

    if [[ "$platform" != "WebGl" ]]; then
        echo "Creating debug symbols zip for $platform..."
        cd "$build_path/${project_name}_BackUpThisFolder_ButDontShipItWithYourGame" \
            && time zip -9qr "$output_path/${project_name}_${platform}_${version}_debug_symbols.zip" .
    fi

    echo "Platform \"$platform\" done!"
done
