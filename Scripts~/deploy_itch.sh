#!/bin/bash

set -e

butler_path="butler"
build_artifact_path="./Builds"
version=""
platforms=""

project_name="ItsNottheEndoftheWorld"
itch_project_name="its-not-the-end-of-the-world"

while getopts "u:o:d:v:p:" flag
do
    case "$flag" in
        b) butler_path="$OPTARG";;
        a) build_artifact_path="$OPTARG";;
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

echo "Version = $version"

build_artifact_path=$(realpath "$build_artifact_path")
echo "Output path = $build_artifact_path"

read -r -a split_platforms <<<"$platforms"

for platform in "${split_platforms[@]}"; do
    echo "Deploying $platform..."

    arch="x64"
    platform_lower="$(echo "$platform" | tr "[:upper:]" "[:lower:]")"
    platform_path="$build_artifact_path/$platform"
    manifest_path="$platform_path/.itch.toml"

    if [[ "$platform" = "OsxUniversal" ]]; then
        arch=""
        platform_lower="osx"
    elif [[ "$platform" = "OsxSilicon" ]]; then
        arch="arm64"
        platform_lower="osx"
    elif [[ "$platform" = "OsxIntel" ]]; then
        platform_lower="osx"
    elif [[ "$platform" = "WebGl" ]]; then
        platform_lower="html"
    fi

    # See: https://itch.io/docs/itch/integrating/manifest-actions.html
    extension="app"

    if [[ "$platform" = "Linux" ]]; then
        extension="x86_64"
    elif [[ "$platform" = "Windows" ]]; then
        extension="exe"
    fi

    if [[ "$platform" = "OsxUniversal" ]] || [[ "$platform" = "WebGl" ]]; then
        tag="$platform_lower"
    else
        tag="$platform_lower-$arch"
    fi

    # Generate itch.toml for platforms except WebGL
    if [[ "$platform" != "WebGl" ]]; then
        echo "[[actions]]
        name = \"play\"
        platform = \"$platform_lower\"
        path = \"$project_name.$extension\"
        sandbox = true" 1> "$manifest_path"

        "$butler_path" validate --assume-yes "$platform_path"
    fi

    "$butler_path" push \
        --userversion="$version" \
        --assume-yes \
        --fix-permissions \
        --ignore "*ButDontShipItWithYourGame*" \
        --ignore "*DoNotShip*" \
        --ignore "*.pdb" \
        --ignore "*.debug" \
        --ignore "*.DS_Store" \
        --ignore "*.zip" \
        --ignore "*.tar" \
        --ignore "*.tar.gz" \
        "$build_artifact_path/$platform" braska/$itch_project_name:"$tag"

    echo "$platform done!"
done
