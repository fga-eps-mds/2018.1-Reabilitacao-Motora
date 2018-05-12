#! /bin/sh
echo "========================================"
echo 'ATTEMPTING TO UPLOAD BUILDS'
cd Reabilitacao-Motora/Build
echo "Current folder contains:"
ls
echo "========================================"
echo 'Attempting to upload Windows build'
curl -X POST -i -F file_object=@windows.zip ec2-54-233-228-194.sa-east-1.compute.amazonaws.com:3000/file_objects/devel/Windows
echo "========================================"
echo 'Attempting to upload Linux build'
curl -X POST -i -F file_object=@linux.zip ec2-54-233-228-194.sa-east-1.compute.amazonaws.com:3000/file_objects/devel/Linux
echo "========================================"
echo 'Attempting to upload OSX build'
curl -X POST -i -F file_object=@osx.zip ec2-54-233-228-194.sa-east-1.compute.amazonaws.com:3000/file_objects/devel/OSX
echo "========================================"
