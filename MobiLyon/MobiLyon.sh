#!/bin/bash
echo "10 seconds to go..."
/bin/sleep 1
for i in 9 8 7 6 5 4 3 2 1 ; do \
  echo " $i seconds to go..." && \
  /bin/sleep 1 ; \
done
/home/quinn/Projects/MobiLyon/MobiLyon.py
exit
