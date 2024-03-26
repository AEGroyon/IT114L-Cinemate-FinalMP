<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/SiteNav.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="IT114L_Cinemate_FinalMP.Profile" %>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Profile Container */
        .profile-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Profile Info Section */
        .profile-info {
            margin-bottom: 20px;
        }

        .profile-label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .profile-textbox {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .profile-button {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .profile-button:hover {
            background-color: #0056b3;
        }

        /* Booking History Section */
        .booking-history {
            border-top: 1px solid #ccc;
            padding-top: 20px;
        }

        .booking-grid {
            width: 100%;
            border-collapse: collapse;
        }

        .booking-grid th, .booking-grid td {
            padding: 8px;
            border-bottom: 1px solid #ccc;
        }

        .booking-grid th {
            background-color: #007bff;
            color: #fff;
            text-align: left;
        }

        .booking-grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .booking-grid tr:hover {
            background-color: #e2e6ea;
        }

        /* Media Queries */
        @media (max-width: 768px) {
            .profile-container {
                padding: 10px;
            }

            .profile-textbox {
                padding: 6px;
            }

            .profile-button {
                padding: 8px 16px;
            }
        }

        @media (max-width: 576px) {
            .profile-textbox {
                padding: 5px;
            }

            .profile-button {
                padding: 6px 12px;
            }
        }
    </style>
    <br />
    <div class="profile-container">
        <h2>User Profile</h2>
        <div class="profile-info">
            <asp:Label ID="lblUsername" runat="server" Text="Username:" CssClass="profile-label" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="profile-textbox" />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="profile-label" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="profile-textbox" />
            <br />
            <asp:Label ID="showLblPassword" runat="server" Text="Password:" CssClass="profile-label" />
            <asp:TextBox ID="showTxtPassword" runat="server" CssClass="profile-textbox" ReadOnly="true" />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Change Password:" CssClass="profile-label" />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="profile-textbox" TextMode="Password" />
            <br />
            <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" OnClick="btnUpdateProfile_Click" CssClass="profile-button" />
        </div>
        <div class="booking-history">
            <h3>Booking History</h3>
            <asp:GridView ID="gvBookingHistory" runat="server" AutoGenerateColumns="False" CssClass="booking-grid">
                <Columns>
                    <asp:BoundField DataField="BookingID" HeaderText="Booking ID" />
                    <asp:BoundField DataField="MovieTitle" HeaderText="Movie Title" />
                    <asp:BoundField DataField="ShowDate" HeaderText="Show Date" />
                    <asp:BoundField DataField="SeatNumber" HeaderText="Seat Number" />
                    <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
