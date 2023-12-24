#!/bin/bash

numbername () {
    printf "%03d" "$1"
}

getname () {
    i=0
    while true
    do
        file="$(numbername $i)"
        if [[ ! -f "$file" ]]; then
            echo "$file"
            return
        fi
        i=$((i+1))
    done
}

writeinFile () {
    fileName=$(getname)
    echo "$CONTAINER_ID $fileName" > "$fileName"
    echo "$fileName"
}

SLEEP_TIME=1

cd /shared || exit

while true 
do
    if [[ $current ]]; then
        flock -s "$current" -c "rm $current"
        echo "$current is deleted"
        current=""
    else
        current=$(flock -s ".lock" -c "echo $(writeinFile)")
        echo "$current is created"
    fi

    sleep $SLEEP_TIME
done
