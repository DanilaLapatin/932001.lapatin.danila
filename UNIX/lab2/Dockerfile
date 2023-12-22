# Base alpine image
FROM alpine

# Add bash
RUN apk --no-cache add bash

#Create connection port to the directory for const data
VOLUME ./SharDir

# Add work directory to the container
WORKDIR /

# Add the script to the container
COPY ./script.sh ./

# Run the script when container starts
CMD ["./script.sh"]
