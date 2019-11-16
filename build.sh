#!/usr/bin/env bash


# Changes sequentially every 100 seconds
buildNumber=`expr $(date +%s) / 100`

function semverParseInto() {
    local RE='[^0-9]*\([0-9]*\)[.]\([0-9]*\)[.]\([0-9]*\)\([0-9A-Za-z-]*\)'
    #MAJOR
    eval $2=`echo $1 | sed -e "s#$RE#\1#"`
    #MINOR
    eval $3=`echo $1 | sed -e "s#$RE#\2#"`
    #MINOR
    eval $4=`echo $1 | sed -e "s#$RE#\3#"`
    #SPECIAL
    eval $5=`echo $1 | sed -e "s#$RE#\4#"`
}

# Clean build dir
if [[ -f "./bin" ]]; then 
    rm -rf ./bin
fi

if [[ -f "version" ]]; then 
    version=`cat version`
else
    echo "Could not determine version, make sure you are running this from the root directory and the version file exists"
    exit 1
fi

semverParseInto ${version} MAJOR MINOR PATCH SPECIAL

buildDate=$(date +%Y%m%_d%H%M%S)  

if [[ -z "$SPECIAL" ]]; then
    versionNumber="${MAJOR}.${MINOR}.${PATCH}"
    
    dotnet pack --configuration Release -o ./bin \
        -p:Version="${MAJOR}.${MINOR}.${PATCH}" \
        -p:InformationalVersion="${versionNumber} (${buildDate})" \
        ./src/Naveego.Sdk.sln
         
else 
    versionNumber="${MAJOR}.${MINOR}.${PATCH}${SPECIAL}.${buildNumber}+${buildDate}"
    
    dotnet pack --configuration Release -o ./bin \
        -p:VersionPrefix="${MAJOR}.${MINOR}.${PATCH}" \
        -p:VersionSuffix="${SPECIAL:1}.${buildNumber}" \
        -p:InformationalVersion="${versionNumber}" \
        ./src/Naveego.Sdk.sln
fi

status=$?

if [[ ${status} -eq 0 ]]; then
    echo "Successfully Build Plugin SDK ($versionNumber)"
else 
    exit 1
fi