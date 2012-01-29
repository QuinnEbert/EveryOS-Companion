;; 
;; Winemory - Cheap (but effective) Memory Statistics Gatherer for use with HollyHug
;; Written on July 04, 2009, by D. Quinn Ebert <quinnebert (at) gmail (dot) com>
;; On The Web at www.QuinnEbert.net
;; 

; Get the memory statistics...
$memstat = MemGetStats()

; PERSONAL REFERENCE (FROM THE AUTOIT MANUAL/HELPFILE):
;
;  $array[0] = Memory Load (Percentage of memory in use)
;  $array[1] = Total physical RAM
;  $array[2] = Available physical RAM
;  $array[3] = Total Pagefile
;  $array[4] = Available Pagefile
;  $array[5] = Total virtual
;  $array[6] = Available virtual

; Make the Memory Stats a bit more "digestable"...
;NOTE: Variable names correspond to those in the PHP class, if you wonder where the wacky arrangements came from...  ;)
$a = Int(($memstat[1] / 1024))
$c = Int(($memstat[2] / 1024))
$b = ($a - $c)
$g = Int(($memstat[3] / 1024))
$i = Int(($memstat[4] / 1024))
$h = ($g - $i)

; And, FINALLY, output something "useful"...
ConsoleWrite($a & "," & $b & "," & $c & ",0,0,0," & $g & "," & $h & "," & $i)
