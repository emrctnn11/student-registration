using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace StudentRegistration.Hubs;

[AllowAnonymous]
public class StudentHub : Hub
{
}