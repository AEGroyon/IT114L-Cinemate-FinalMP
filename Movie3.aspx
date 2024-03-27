<%@ Page Title="" Language="C#" MasterPageFile="~/SiteNav.Master" AutoEventWireup="true" CodeBehind="Movie3.aspx.cs" Inherits="IT114L_Cinemate_FinalMP.Movie3" %>

<asp:Content ID="Movie3Content" ContentPlaceHolderID="MainContent" runat="server">
    <style>
         body {
            background-color: #121212;
         }
         /* Container for movie details and seat selection */
         .movie-details-container {
             display: flex;
             flex-direction: column;
             align-items: center;
             margin-top: 50px;
         }

         /* Movie info section */
         .movie-info {
             margin-top: 15px;
             margin-bottom: -25px;
             text-align: center;
             color: #fff;
         }

         .synopsis-container {
             width: 48em;
             height: 6em;
             border: 1px solid #ccc;
             border-radius: 5px;
             padding: 10px;
             margin-top: 10px;
             margin-bottom: 15px;
             background-color: #292929;
         }


         h3{
             color: #fff;
         }

         /* Poster image */
         .poster-image {
             width: 16em;
             height: 8em;
             border-radius: 5px;
             box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
         }

         /* Seat selection container */
         .seat-selection-container {
             margin-top: 30px;
             text-align: center;
         }

         /* Seat panel */
         .seat-panel {
             margin-bottom: 10px;
         }

         /* Seat buttons */
         .seat-btn {
             width: 50px;
             height: 50px;
             margin: 5px;
             font-size: 18px;
             background-color: #D1A14A;
             color: #fff;
             border: none;
             border-radius: 5px;
             transition: background-color 0.3s ease;
             cursor: pointer;
         }

         .seat-btn:hover {
             background-color: #292929;
         }

         .book-seat-button {
             width: 100px;
             height: 40px;
             margin: 5px;
             font-size: 18px;
             background-color: #D1A14A;
             color: #fff;
             border: none;
             border-radius: 5px;
             transition: background-color 0.3s ease;
             cursor: pointer;
             margin-top: -15px;
         }

         .book-seat-button:hover {
             background-color: #292929;
         }


         /* Responsive design */
         @media screen and (max-width: 768px) {
             .seat-btn {
                 width: 40px;
                 height: 40px;
                 font-size: 14px;
             }

             .seat-panel {
                 margin-bottom: 5px;
             }

             .movie-details-container {
                 flex-direction: column;
             }

             .movie-poster {
                 width: 100%;
                 margin-bottom: 20px;
             }

             .movie-info {
                 width: 100%;
             }

             .synopsis-container {
                 width: 90%;
                 height: auto;
                 margin: 0 auto 10px;
             }

             .seat-selection-container {
                 width: 100%;
             }
         }
     </style>
     <div class="movie-details-container">
         <div class="movie-info">
             <h2><asp:Label ID="lblMovieTitle" runat="server" CssClass="movie-title" /></h2>
             <p><asp:Label ID="lblDuration" runat="server" CssClass="movie-info-label" /></p>
             <div class="synopsis-container">
                 <p><asp:Label ID="lblSynopsis" runat="server" CssClass="movie-info-textbox" /></p>
             </div>
             <%--<p><asp:Label ID="lblSynopsis" runat="server" CssClass="movie-info-label" /></p>--%>
             <p><asp:Label ID="lblShowDate" runat="server" CssClass="movie-info-label" /></p>
             <p><asp:Label ID="lblShowTime" runat="server" CssClass="movie-info-label" /></p>
             <p><asp:Label ID="lblTicketPrice" runat="server" CssClass="movie-info-label" /></p>
         </div>
         <div class="seat-selection-container">
             <!-- Seat selection -->
             <h3>Select your seats</h3>

             <!-- Theater layout -->
             <div class="theater-layout">
                 <!-- Screen -->
                 <div class="movie-poster">
                     <asp:Image ID="imgMoviePoster" runat="server" CssClass="poster-image" ImageUrl="~/Img/Kung Fu Panda 4.jpg"/>
                 </div>
                 <br />

                 <!-- Seats -->
                 <div class="seat-panel">
                     <asp:Button ID="A1Btn" runat="server" Text="A1" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="A2Btn" runat="server" Text="A2" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="A3Btn" runat="server" Text="A3" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="A4Btn" runat="server" Text="A4" CssClass="seat-btn" OnClick="SeatButton_Click" />
                 </div>

                 <div class="seat-panel">
                     <asp:Button ID="B1Btn" runat="server" Text="B1" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="B2Btn" runat="server" Text="B2" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="B3Btn" runat="server" Text="B3" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="B4Btn" runat="server" Text="B4" CssClass="seat-btn" OnClick="SeatButton_Click" />
                 </div>

                 <div class="seat-panel">
                     <asp:Button ID="C1Btn" runat="server" Text="C1" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="C2Btn" runat="server" Text="C2" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="C3Btn" runat="server" Text="C3" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="C4Btn" runat="server" Text="C4" CssClass="seat-btn" OnClick="SeatButton_Click" />
                 </div>

                 <div class="seat-panel">
                     <asp:Button ID="D1Btn" runat="server" Text="D1" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="D2Btn" runat="server" Text="D2" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="D3Btn" runat="server" Text="D3" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="D4Btn" runat="server" Text="D4" CssClass="seat-btn" OnClick="SeatButton_Click" />
                 </div>

                 <div class="seat-panel">
                     <asp:Button ID="E1Btn" runat="server" Text="E1" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="E2Btn" runat="server" Text="E2" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="E3Btn" runat="server" Text="E3" CssClass="seat-btn" OnClick="SeatButton_Click" />
                     <asp:Button ID="E4Btn" runat="server" Text="E4" CssClass="seat-btn" OnClick="SeatButton_Click" />
                 </div>
             </div>
             <br />
             <asp:TextBox ID="showSeatNumber" runat="server" CssClass="seat-textbox" ReadOnly="true" />
             <br /> <br />
             <asp:Button ID="btnBookSeat" runat="server" Text="Book Seat" CssClass="book-seat-button" OnClick="btnBookSeat_Click"/>
             <br /> <br />
         </div>
     </div>
</asp:Content>

