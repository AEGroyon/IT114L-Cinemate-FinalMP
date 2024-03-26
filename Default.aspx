<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IT114L_Cinemate_FinalMP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Login / Register </title>
    <link href="LoginStyles.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            background-image: url('https://images5.alphacoders.com/133/thumb-1920-1331568.png');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .container {
            position: relative;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            color: gold;
        }

        .card {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background: rgba(255, 255, 255, 0.5);
            border-radius: 20px;
            padding: 20px;
            box-shadow: 0 8px 32px 0 rgba(31, 38, 135, 0.37);
            border: 2px solid rgba(255, 255, 255, 0.5);
            overflow: hidden;
            width: 300px;
            text-align: center;
        }

            .card h2 {
                text-align: center;
                color: red;
                margin-bottom: 20px;
            }

        .input {
            padding: 10px;
            margin-bottom: 15px;
            border: none;
            border-radius: 5px;
            background: rgba(255, 255, 255, 0.3);
            color: #333;
            outline: none;
            transition: background 0.3s ease-in-out;
        }

            .input::placeholder {
                color: #666;
            }

            .input:focus {
                background: rgba(255, 255, 255, 0.5);
            }

        .button,
        .toggle-button {
            cursor: pointer;
            background: linear-gradient(145deg, #ffcc00, #cc9900);
            border: none;
            color: #fff;
            font-weight: bold;
            padding: 10px 20px;
            border-radius: 5px;
            transition: background 0.3s ease-in-out;
        }

            .button:hover,
            .toggle-button:hover {
                background: linear-gradient(145deg, #cc9900, #ffcc00);
            }

        .toggle-button {
            background: linear-gradient(145deg, #ff3300, #cc0000);
            margin-top: 20px;
        }

            .toggle-button:hover {
                background: linear-gradient(145deg, #cc0000, #ff3300);
            }

        .logo {
            position: absolute;
            top: 10px;
            left: 50%;
            transform: translateX(-50%);
            width: 300px;
            height: 300px;
        }

    </style>
</head>
<body>
    <div class="background">
        <img src="https://i.ibb.co/gzck6MF/432428416-825075846062836-4797110355704877286-n-1.png" alt="Logo" class="logo" /> </div>
    <form id="form1" runat="server">
        <div class="container">
            <div id="loginContainer" class="panel-container">
                <div id="loginPanel" class="card login-card active flip">
                    <h2>Login</h2>
                    <asp:TextBox ID="username" runat="server" CssClass="input" placeholder="Username"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="loginButton" runat="server" Text="Login" CssClass="button" OnClick="loginButton_Click" />
                    <asp:Button ID="SignButton" runat="server" Text="Sign Up" CssClass="button" OnClick="SignButton_Click" />
                </div>
            </div>
        </div>
    </form>
    <form id ="form2" runat ="server">
        <div class="container">
            <div id="signupContainer" class="panel-container">
                <div id="signupPanel" class="card signup-card flip">
                    <h2>Sign Up</h2>
                    <asp:TextBox ID="newUsername" runat="server" CssClass="input" placeholder="Username"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="email" runat="server" CssClass="input" TextMode="email" placeholder="Email"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="newPassword" runat="server" CssClass="input" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="signupButton" runat="server" Text="Sign Up" CssClass="button" OnClick="signupButton_Click" />
                    <asp:Button ID="LogButton" runat="server" Text="Login" CssClass="button" OnClick="LogButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
