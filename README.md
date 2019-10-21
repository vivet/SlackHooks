# SlackHooks
[![Build status](https://ci.appveyor.com/api/projects/status/jthe8r7hqch4bx04/branch/master?svg=true)](https://ci.appveyor.com/project/vivet/slackhooks/branch/master)
[![NuGet](https://img.shields.io/nuget/dt/SlackHooks.svg)](https://www.nuget.org/packages/SlackHooks)
[![NuGet](https://img.shields.io/nuget/v/SlackHooks.svg)](https://www.nuget.org/packages/SlackHooks)  

Light-weight Slack Client for posting messages to channels using webhooks.  

***

### Getting started...
Send simple or complex messages to slack channels, as shown below.  

##### Simple Message
```csharp
var baseUrl = "https://hooks.slack.com/services/XXXXXXXXX"; // The base url of the Slack app.
var channelPath = "XXXXXXXXX/xXxxxXxxxXXxxxxXXxXxx"; // The channel path.

var message = new Message()
    .SetChannel(channel)
    .SetText("test-text");

using (var client = new SlackClient(new Uri(baseUrl)))
{
	var result = await client
		.SendMessageAsync(message);

}
```

##### Complex Message
```csharp
var baseUrl = "https://hooks.slack.com/services/XXXXXXXXX"; // The base url of the Slack app.
var channelPath = "XXXXXXXXX/xXxxxXxxxXXxxxxXXxXxx"; // The channel path.

var message = new Message()
    .SetChannel(channel)
    .AddAttachment(x => x
        .SetTitle(y => y
            .SetText("test-title")
            .SetLinkUrl("https://slack.com"))
        .SetText("test-text")
        .SetAuthor(y => y
            .SetName("test-auhtor")
            .SetLinkUrl("http://slack.com")
            .SetIconUrl("https://platform.slack-edge.com/img/default_application_icon.png"))
        .SetFallbackText("falback-text")
        .SetColor(Color.Green)
        .SetImageUrl("https://platform.slack-edge.com/img/default_application_icon.png")
        .SetThumbUrl("https://platform.slack-edge.com/img/default_application_icon.png")
        .SetFooter(y => y
            .SetText("text-footer")
            .SetIconUrl("https://platform.slack-edge.com/img/default_application_icon.png"))                );

using (var client = new SlackClient(new Uri(baseUrl)))
{
	var result = await client
		.SendMessageAsync(message);

}
```

***
