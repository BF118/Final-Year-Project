# Final-Year-Project
# Discord Event Organiser Bot/Website

# Getting Started
  * Overview
  * Discord Bot
  * Website

## Overview
The aim of this Project is to create an event organiser for raid like encounters in MMO games like Runescape, Wow and New Worlds
This Repository consists of two parts one being the Discord bot the other being a website
Each of which need some setting up

## Discord bot Setup
### Requirements
  * Microsoft Visual Studion
  * Discord.net
  * Discord.Addons.Interactive
  * Microsoft.Extensions.Configuration.EnvironmentVariables


### Discord.net
* Can be installed through NuGet Packages in Visual Studio
* NuGet Search `Discord.net`
* `Install-Package Discord.Net -Version 3.6.1`
* This will install the Discord.net library as well as additional libraries for webhooks etc
* [Official documentation](https://discordnet.dev/guides/getting_started/installing.html?tabs=vs-install%2Ccustom-pkg)

### Discord.Addons.Interactive
* Can be installed through NuGet Packages in Visual Studio
* NuGet Search `Discord.Addons.Interactive`
* `Install-Package Discord.Addons.Interactive -Version 2.0.0`
* [Official documentation](https://github.com/foxbot/Discord.Addons.Interactive)

### Microsoft.Extensions.Configuration.EnvironmentVariables
* Can be installed through NuGet Packages in Visual Studio
* NuGet Search `Microsoft.Extensions.Configuration.EnvironmentVariables`
* `Install-Package Microsoft.Extensions.Configuration.EnvironmentVariables -Version 6.0.1`
* [Official documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.environmentvariables.environmentvariablesconfigurationprovider?view=dotnet-plat-ext-6.0)

### Setting Up Bot
1. Create a new application in the [Discord Developer Portal](https://discord.com/developers/applications)
2. Go to the bot section and click Add bot
3. Copy the bot token from the build-a-bot menu
4. In windows create an [Environment Variables](https://docs.oracle.com/en/database/oracle/machine-learning/oml4r/1.5.1/oread/creating-and-modifying-environment-variables-on-windows.html) Named Token
5. To invite the bot to a server in the Discord Developer Portal go to Oauth2 then URL Generator
6. Copy URL and paste in search bar 
7. Select the server you want to bot to be on

### Configuring Server
Now the bot is in the server it needs configuring to get it to work
1. Give bot Administrator Permissions
2. Type `!setup` in any text channel
3. Check to see if new roles are in server settings

### Using the bot
All Commands should be written in any text channel
 * `!help` Brings up list of commands
 * `!role help` Shows embed of all things to do with roles
 * `!role list` Shows list of Encounters
 * `!encounter'1-4' time 'startime'` Brings up encounter signup sheet
* The prefix to trigger the bot is set to ! as default this can be changed in program.cs

## Website
The website part of the system is 4 html pages with java script and css for styling
* Part of the website uses webhooks that link with Discord this need some configuring

###

test push
http://bf118.webhosting.canterbury.ac.uk/
https://pretagteam.com/question/discord-send-messages-from-a-channel-to-my-website-in-real-time
https://dev.to/oskarcodes/send-automated-discord-messages-through-webhooks-using-javascript-1p01
https://dev.to/oskarcodes/send-automated-discord-messages-through-webhooks-using-javascript-part-2-embeds-588n
https://discordnet.dev/guides/concepts/events.html
