using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Services.ChatHub
{
    public class ChatHub : Hub
    {
        //private readonly IHttpContextAccessor httpContextAccessor;
        //private readonly IMapper mapper;
        //private IServiceProvider _sp;
       
        public enum ResponseMethods
        {
            errorlistener,
            connectedlistener,
            Discordlistener,
            Twitterlistener,
        }
        Dictionary<string, string> ConnectedUserList = new Dictionary<string, string>();
        public override async Task OnConnected()
        {
            try
            {
                var Token = "";//Request.LoginID();
                if (Token != null && !string.IsNullOrEmpty(Token))
                {
                    var ChkToken = ConnectedUserList.ContainsValue(Token);
                    if (ChkToken)
                    {
                        var Value = ConnectedUserList.Where(a => a.Value == Token).FirstOrDefault();
                        ConnectedUserList.Remove(Value.Key);
                    }
                    ConnectedUserList.Add(Context.ConnectionId, Token);
                    await Clients.Caller.SendAsync(ResponseMethods.connectedlistener.ToString(), "Connected successfully");
                }
            }
            catch (Exception ex)
            {
                await sendError("Connection failed");
            }
            await base.OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            if (Clients != null)
            {
                ConnectedUserList.Remove(Context.ConnectionId);
                await base.OnDisconnected(stopCalled);
            }
        }
        //public async Task SendDiscordToken(MessagesResponse Message)
        //{
        //    try
        //    {
        //        if (Clients != null)
        //        {
        //            var ChkToken = ConnectedUserList.ContainsValue(Message.Access_Token);
        //            if (ChkToken)
        //            {
        //                var Value = ConnectedUserList.Where(a => a.Value == Message.Access_Token).FirstOrDefault();
        //                await Clients.Client(Value.Key).SendAsync(ResponseMethods.Discordlistener.ToString(), Message.Code);
        //            }
        //            else
        //                await Clients.Client(Context.ConnectionId).SendAsync(ResponseMethods.Discordlistener.ToString(), "User not found");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //await sendError("Connection failed");
        //    }
        //}
        //public async Task SendTwitterToken(MessagesResponse Message)
        //{
        //    try
        //    {
        //        if (Clients != null)
        //        {
        //            var ChkToken = ConnectedUserList.ContainsValue(Message.Access_Token);
        //            if (ChkToken)
        //            {
        //                var Value = ConnectedUserList.Where(a => a.Value == Message.Access_Token).FirstOrDefault();
        //                await Clients.Client(Value.Key).SendAsync(ResponseMethods.Twitterlistener.ToString(), Message.Code + ',' + Message.AuthVerifier);
        //            }
        //            else
        //                await Clients.Client(Context.ConnectionId).SendAsync(ResponseMethods.Twitterlistener.ToString(), "User not found");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //await sendError("Connection failed");
        //    }
        //}
        
        private async Task sendError(string error)
        {
            await Clients.Caller.SendAsync(ResponseMethods.errorlistener.ToString(), error);
        }
    }
}
