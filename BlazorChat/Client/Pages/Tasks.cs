using BlazorChat.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorChat.Client.Pages
{
    public partial class Tasks
    {
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        [Parameter] public string CurrentMessage { get; set; }
        [Parameter] public string CurrentUserId { get; set; }
        [Parameter] public string CurrentUserEmail { get; set; }
        public bool IsTask { get; set; }
        private List<ChatMessage> messages = new List<ChatMessage>();
        public List<ApplicationUser> ChatUsers = new List<ApplicationUser>();
        [Parameter] public string ContactEmail { get; set; }
        [Parameter] public string ContactId { get; set; }

        async Task LoadUserChat(string userId)
        {
            var contact = await _chatManager.GetUserDetailsAsync(userId);
            ContactId = contact.Id;
            ContactEmail = contact.Email;
            _navigationManager.NavigateTo($"chat/{ContactId}");
            messages = new List<ChatMessage>();
            messages = await _chatManager.GetConversationAsync(ContactId);
        }
        private async Task GetUsersAsync()
        {
            ChatUsers = await _chatManager.GetUsersAsync();
        }
    }
}
