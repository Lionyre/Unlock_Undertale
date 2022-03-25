echo Hello 
set unity=C:\Program Files\Unity\Hub\Editor\2020.3.20f1\Editor\Unity.exe

git pull
"%unity%" -quit -batchmode -executeMethod BuildWebGL.Build
cd Builds

cd .. 