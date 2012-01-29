<?php
  
  // FIXME: These should be easily made universal...
  $ckCmd = "sc query ctaudsvcservice";
  $is_OK = "SERVICE_NAME: ctaudsvcservice";
  
  $stdIn = `$ckCmd`;
  
  if (strstr($stdIn,$is_OK))
    die("OK\n");
  die("NO\n");
  