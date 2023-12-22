#!/bin/bash

# Number of containers
count=$1

if [[ ! $count ]]
{
    count=1
}

# Preliminary removing of volume
./remove.sh

dir=$(pwd -W)

for i in $(seq 1 $count)
do
    # Bind volume
    # Run container in background and print container ID
    docker run -v "$dir/SharDir":/SharDir -d myImage
done