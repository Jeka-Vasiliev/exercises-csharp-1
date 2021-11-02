ts=$(date +%s%N)
../../../bin/out/Project Exercise.csx 2>&1
echo $((($(date +%s%N) - $ts)/1000000))