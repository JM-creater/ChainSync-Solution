using ChainSyncSolution.Application.Interfaces.IEmail;
using Microsoft.Extensions.Configuration;

namespace ChainSyncSolution.Infrastructure.Common.Email;

public class EmailContentProvider : IEmailContentProvider
{
    private readonly IConfiguration _configuration;

    public EmailContentProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendPasswordForgotEmail(string email, string token)
    {
        string resetLink = $"http://localhost:5173/forgot-password?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}";
        string subject = "Password Reset Request";
        string message = $@"
                <html>
                    <head>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                color: #333;
                                background-color: #f4f4f4;
                                padding: 20px;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 0 auto;
                                background: #fff;
                                padding: 20px;
                                border-radius: 8px;
                                box-shadow: 0 0 10px rgba(0,0,0,0.1);
                            }}
                            .button {{
                                display: inline-block;
                                padding: 10px 20px;
                                background-color: #007bff;
                                border-radius: 5px;
                                text-decoration: none;
                                font-weight: bold;
                            }}
                            .button a {{
                                color: #fff; 
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <h2>Password Reset Request</h2>
                            <p>You requested a password reset for your account. Please click the button below to set a new password:</p>
                            <a href='{resetLink}' class='button'>Reset Password</a>
                            <p>If you did not request a password reset, please ignore this email.</p>
                        </div>
                    </body>
                </html>
        ";

        await EmailConfiguration.SendEmailAsync(email, subject, message, _configuration);
    }
}
