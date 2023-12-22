#!/bin/bash/ -e

remove()
{
	echo "Removing temporary directory..."
	rm -rf $tempdir
}

trap remove EXIT INT TERM

file=$1

if [ ! -e $file ]
then
echo "Source file not exists"
exit 1
fi

exe=$(grep "&Output:\w*[.]*\w*" $file | cut -d ':' -f 2)
echo "Output file should be $exe"

if [ -z $exe ]
then
  echo "The required comment was not found in source file"
  exit 1
fi

if [ -e $exe ]
then
	rm $exe
fi

tempdir=$(mktemp -d)

g++ -o "$tempdir/$exe"  "$file"


if [ $? -ne 0 ]
then
	echo "Compilation failed."
	remove
fi


mv "$tempdir/$exe" "./$exe"



echo "Comilation successful"
exit 0