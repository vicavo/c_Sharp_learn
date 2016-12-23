# LICENSE

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

# FEATURES

- Fetch the Public VPN Relay Servers on [VPN Gate](http://www.vpngate.net/) via proxy
- Ping the servers to filter the unreachable ones
- Get the cityname of VPN server with just a click
- Export SSL-VPN connection setting for SoftEther VPN Client Manager

## Getting started

There are two parts for this application: the proxy the the client.

If you can not visit [vpngate.net](http://www.vpngate.net/) directly, you should deploy the proxy.
Upload the proxy file `pagefetcher.php` to a web server which supports PHP, then visit the file from a webbroswer to make sure it works.

Add the full url of the proxy to the file `proxy.list`, you may add multiple proxies for redundancy.

Run the client (make sure .Net Framework 4 is installed), select a proxy and click "Refresh List", a list of public VPN servers will be loaded after a while.
You could ping, locate these servers and export SSL-VPN connection setting.

Finally open SoftEther VPN Client Manager and import the SSL-VPN connection setting file, connect and enjoy surfing.

# IMPORTANT LINKS
- [VPN Gate Academic Experiment Project](http://www.vpngate.net/) is an online service as an academic research at the Graduate School of University of Tsukuba, Japan.
- [freegeoip.net](http://freegeoip.net/) is a public RESTful web service API for searching geolocation of IP addresses and host names.