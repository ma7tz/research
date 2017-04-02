<powershell>
New-NetFirewallRule -DisplayName "PS Remoting" -Direction Inbound -Protocol TCP -LocalPort 5985 -Action Allow

winrm set winrm/config/service/Auth '@{Basic="true"}'
winrm set winrm/config/service '@{AllowUnencrypted="true"}'
winrm set winrm/config/winrs '@{MaxMemoryPerShellMB="1024"}'
</powershell>
