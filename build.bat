set unity=C:\Program Files\Unity\Hub\Editor\2020.3.20f1\Editor\Unity.exe
set butler=C:\Program Files (x86)\butler-windows-amd64\butler.exe
git pull
"%unity%" -quit -batchmode -executeMethod BuildWebGL.Build
cd Builds
tar -a -c -f "WebGL.zip" "WebGL"
"%butler%" push "WebGL.zip" lancer-gaming/epico:html --userversion 0.1