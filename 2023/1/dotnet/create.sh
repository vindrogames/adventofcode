docker run -v $(pwd)/src:$(pwd)/src -it $IMAGE sh -c "cd $(pwd)/src; dotnet new console --framework net7.0 --name $PROJECT -o ."