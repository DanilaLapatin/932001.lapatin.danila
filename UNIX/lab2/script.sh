#!/bin/bash

GetName()
{
    printf "%3d" "$1"
}

GetFreeName()
{
    for i in (seq 1 999)
    do
        file="$(GetName $i)"

        #if file with this name does not exist 
        if [[! -f "$file"]]
        then
        echo "$file"
        return
        fi 
    done
}

MakeFile()
{
    Newfile=$(GetFreeName)

    echo "$CONTAINER_ID $Newfile" > "$Newfile"
    echo "$Newfile"
}

cd ./SharDir || exit

while true 
do
    if [[ $current ]]
    then
        flock -s "$current" -c "rm $current"
        echo "$current is deleted"
        current=""
    else
        current=$(flock -s ".lock" -c "echo $(MakeFile)")
        echo "$current is created"
    fi
    
    sleep 1
done


