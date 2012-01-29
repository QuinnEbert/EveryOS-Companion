#!/bin/bash 
TRAYSVC='notification-area-applet'
if [ "$1" == "--damage" ]; then
  echo "Bringing down the Notification tray services as you request"
  echo " "
  echo "Running GNOME sessions will probably get upset over this..."
  killall $TRAYSVC
fi
while [ "`pidof $TRAYSVC`" == "" ]; do
  echo "Notification tray services are still not available, waiting 1 second more..."
  sleep 1
done
