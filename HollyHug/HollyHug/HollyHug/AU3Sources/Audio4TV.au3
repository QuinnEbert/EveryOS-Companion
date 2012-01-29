Dim $pressup = Int((67/2))
for $i = 1 to 50 step 1
	sleep(330)
	send("{VOLUME_DOWN}")
next
for $i = 1 to $pressup step 1
	sleep(330)
	send("{VOLUME_UP}")
next
exit(0)