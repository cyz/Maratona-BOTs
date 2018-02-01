using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace MaratonaBots.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.PostAsync("**Olá, tudo bem?**");

            var message = activity.CreateReply();

            if (activity.Text.Equals("herocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var heroCard = new HeroCard();
                heroCard.Title = "Planeta";
                heroCard.Subtitle = "Universo";
                heroCard.Images = new List<CardImage>
                {
                    new CardImage("https://images.unsplash.com/photo-1451187580459-43490279c0fa?auto=format&fit=crop&w=752&q=80",
                    "Planeta", new CardAction(ActionTypes.OpenUrl, "Microsoft" , value: "https://www.microsoft.com"))
                };
                heroCard.Buttons = new List<CardAction>
                {
                    new CardAction
                    {
                        Text = "Botão 1",
                        DisplayText = "Display",
                        Title = "Title",
                        Type = ActionTypes.PostBack,
                        Value = "aqui vai um valor"
                    }

                };
                message.Attachments.Add(heroCard.ToAttachment());
            }
            else if (activity.Text.Equals("videocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var videoCard = new VideoCard();
                videoCard.Title = "Um vídeo qualquer";
                videoCard.Subtitle = "Aqui vai um subtitulo";
                videoCard.Autostart = true;
                videoCard.Autoloop = false;
                videoCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("http://download.blender.org/peach/bigbuckbunny_movies/BigBuckBunny_320x180.mp4")
                };
                message.Attachments.Add(videoCard.ToAttachment());
            }
            else if (activity.Text.Equals("audiocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var attachment = CreateAudiocard();
                message.Attachments.Add(attachment);
            }
            else if (activity.Text.Equals("animationcard", StringComparison.InvariantCultureIgnoreCase))
            {
                var attachment = CreateAnimationCard();
                message.Attachments.Add(attachment);
            }
            else if (activity.Text.Equals("carousel", StringComparison.InvariantCultureIgnoreCase))
            {
                message.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                var audio = CreateAudiocard();
                var animation = CreateAnimationCard();

                message.Attachments.Add(audio);
                message.Attachments.Add(animation);
            }

            await context.PostAsync(message);

            context.Wait(MessageReceivedAsync);
        }

        private Attachment CreateAnimationCard()
        {
            var animationCard = new AnimationCard();
            animationCard.Title = "Um áudio revelador";
            animationCard.Subtitle = "Aqui vai um subtitulo";
            animationCard.Autostart = true;
            animationCard.Autoloop = false;
            animationCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("https://img.buzzfeed.com/buzzfeed-static/static/enhanced/webdr06/2013/5/31/10/anigif_enhanced-buzz-3734-1370010471-16.gif")
                };
            return animationCard.ToAttachment();
        }

        private Attachment CreateAudiocard()
        {
            var audioCard = new AudioCard();
            audioCard.Title = "Um áudio revelador";
            audioCard.Image = new ThumbnailUrl("https://images.unsplash.com/photo-1451187580459-43490279c0fa?auto=format&fit=crop&w=752&q=80", "Thumb");
            audioCard.Subtitle = "Aqui vai um subtitulo";
            audioCard.Autostart = true;
            audioCard.Autoloop = false;
            audioCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("http://www.wavlist.com/movies/004/father.wav")
                };

            return audioCard.ToAttachment();
        }
    }
}