<?php

$fu = `powercfg.exe -list`;
$fu = strstr($fu, '-----------------------------------');
$fu = str_replace("-----------------------------------\n",'',$fu);
$fu = trim($fu);
$fu = str_replace('  ',' ',$fu);
$fu = str_replace('Power Scheme GUID: ','',$fu);
$fu = str_replace("\r","",$fu);

$ku = explode("\n",$fu);

foreach($ku as $hu) {
  $hu = "\"".str_replace("\n","",$hu)."\"\r\n";
  $hu = str_replace(")\"",") !\"",$hu);
  $hu = str_replace("\"","",$hu);
  $hu = str_replace(" (",",",$hu);
  $hu = str_replace(") !",",!",$hu);
  $hu = str_replace(") *",",*",$hu);
  echo($hu);
}

?>