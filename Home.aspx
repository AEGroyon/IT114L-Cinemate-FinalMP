<%@ Page Title="Cinemate Movie Ticketing" Language="C#" MasterPageFile="~/SiteNav.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IT114L_Cinemate_FinalMP.Home" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        
        body {
            height: 100vh;
            display: grid;
            /*place-items: center;*/
            overflow: hidden;
        }

        main {
            position: absolute;
            width: 100%;
            height: 100%;
            box-shadow: 0 3px 10px rgba(0,0,0,0.3);
            top: 0%;
            left: 0%;
        }

        .item {
            width: 200px;
            height: 300px;
            list-style-type: none;
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            z-index: 1;
            background-position: center;
            background-size: cover;
            border-radius: 20px;
            box-shadow: 0 20px 30px rgba(255,255,255,0.3) inset;
            transition: transform 0.1s, left 0.75s, top 0.75s, width 0.75s, height 0.75s;

            &:nth-child(1), &:nth-child(2) 
            {
                left: 0;
                top: 0;
                width: 100%;
                height: 100%;
                transform: none;
                border-radius: 0;
                box-shadow: none;
                opacity: 1;
            }

            &:nth-child(3) { left: 50%; }
            &:nth-child(4) { left: calc(50% + 220px); }
            &:nth-child(5) { left: calc(50% + 440px); }
            &:nth-child(6) { left: calc(50% + 660px); opacity: 0; }
        }

        .content {
            background-color: rgba(72,72,72,0.3);
            width: min(30vw,400px);
            position: absolute;
            top: 50%;
            left: 3rem;
            transform: translateY(-50%);
            font: 400 0.85rem helvetica,sans-serif;
            color: white;
            text-shadow: 0 3px 10px rgba(0,0,0,0.5);
            opacity: 0;
            display: none;
            border-radius:15px;
            padding: 10px;

            & .title
            {
                font-family: 'arial-black';
                text-transform: uppercase;
            }

            & .description 
            {
                line-height: 1.7;
                margin: 1rem 0 1.5rem;
                font-size: 1rem;
            }

            & .homeBtn {
                width: fit-content;
                background-color: rgba(0,0,0,0.1);
                color: white;
                border: 2px solid white;
                border-radius: 0.25rem;
                padding: 0.75rem;
                cursor: pointer;
            }
        }

        .item:nth-of-type(2) .content {
            display: block;
            animation: show 0.75s ease-in-out 0.3s forwards;
        }

        @keyframes show {
            0% {
            filter: blur(5px);
            transform: translateY(calc(-50% + 75px));
            }
            100% {
            opacity: 1;
            filter: blur(0);
            }
        }

        .navHome {
            position: absolute;
            bottom: 2rem;
            left: 50%;
            transform: translateX(-50%);
            z-index: 5;
            user-select: none;

            & .btn 
            {
                background-color: rgba(255,255,255,0.5);
                color: rgba(0,0,0,0.7);
                border: 2px solid rgba(0,0,0,0.6);
                margin: 0 0.25rem;
                padding: 0.75rem;
                border-radius: 50%;
                cursor: pointer;

                &:hover 
                {
                    background-color: rgba(255,255,255,0.3);
                }
            }
        }

        @media (width > 650px) and (width < 900px) {
            .content {
                & .title        { font-size: 1rem; }
                & .description  { font-size: 0.7rem; }
                & .homeBtn        { font-size: 0.7rem; }
            }
            .item {
                width: 160px;
                height: 270px;

                &:nth-child(3) { left: 50%; }
                &:nth-child(4) { left: calc(50% + 170px); }
                &:nth-child(5) { left: calc(50% + 340px); }
                &:nth-child(6) { left: calc(50% + 510px); opacity: 0; }
            }
        }

        @media (width < 650px) {
            .content {
                & .title        { font-size: 0.9rem; }
                & .description  { font-size: 0.65rem; }
                & .homeBtn        { font-size: 0.7rem; }
            }
            .item {
                width: 130px;
                height: 220px;

                &:nth-child(3) { left: 50%; }
                &:nth-child(4) { left: calc(50% + 140px); }
                &:nth-child(5) { left: calc(50% + 280px); }
                &:nth-child(6) { left: calc(50% + 420px); opacity: 0; }
            }
        }
    </style>
    <body>
        <main>
            <ul class='slider'>
                <li class='item' style="background-image: url('Img/GxK.jpg')">
                    <div class='content'>
                        <h2 class='title'>GODZILLA X KONG: THE NEW EMPIRE</h2>
                        <p class='description'> 
                            Godzilla and the almighty Kong face a colossal threat hidden deep within the planet, challenging their very existence and the survival of the human race.
                        </p>
                        <asp:Button ID="MovieButton1" runat="server" Text="Coming Soon..." CssClass="homeBtn"/>
                    </div>
                </li>
                <li class='item' style="background-image: url('Img/Dune Part Two.jpg')">
                    <div class='content'>
                        <h2 class='title'>DUNE: PART TWO</h2>
                        <p class='description'>
                            Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family. Facing a choice between the love of his life and the fate of the universe, he must prevent a terrible future only he can foresee. 
                        </p>
                        <asp:Button ID="MovieButton2" runat="server" Text="Book Now" CssClass="homeBtn" OnClick="Movie1Button_Click" />
                    </div>
                </li>
                <li class='item' style="background-image: url('Img/SpyFamily.jpg')">
                    <div class='content'>
                        <h2 class='title'>SPY X FAMILY CODE: WHITE</h2>
                        <p class='description'> 
                            After receiving an order to be replaced in Operation Strix, Loid decides to help Anya win a cooking competition at Eden Academy by making the principal's favorite meal in order to prevent his replacement.
                        </p>
                        <asp:Button ID="MovieButton3" runat="server" Text="Book Now" CssClass="homeBtn" OnClick="Movie2Button_Click" />
                    </div>
                </li>
                <li class='item' style="background-image: url('Img/Kung Fu Panda 4.jpg')">
                    <div class='content'>
                        <h2 class='title'>KUNG FU PANDA 4</h2>
                        <p class='description'>
                            After Po is tapped to become the Spiritual Leader of the Valley of Peace, he needs to find and train a new Dragon Warrior, while a wicked sorceress plans to re-summon all the master villains whom Po has vanquished to the spirit realm.
                        </p>
                        <asp:Button ID="MovieButton4" runat="server" Text="Book Now" CssClass="homeBtn" OnClick="Movie3Button_Click" />
                    </div>
                </li>
                <li class='item' style="background-image: url('Img/Kingdom of the Planet of the Apes.jpg')">
                    <div class='content'>
                        <h2 class='title'>KINGDOM OF THE PLANET OF THE APES</h2>
                        <p class='description'>
                            Many years after the reign of Caesar, a young ape goes on a journey that will lead him to question everything he's been taught about the past and make choices that will define a future for apes and humans alike.
                        </p>
                        <asp:Button ID="MovieButton5" runat="server" Text="Coming Soon..." CssClass="homeBtn"/>
                    </div>
                </li>
                <li class='item' style="background-image: url('Img/Inside Out 2.jpg')">
                    <div class='content'>
                        <h2 class='title'>"INSIDE OUT 2</h2>
                        <p class='description'> 
                            Follow Riley, in her teenage years, encountering new emotions. Joy, Sadness, Anger, Fear and Disgust have been running a successful operation by all accounts. However, when Anxiety shows up, they aren't sure how to feel.
                        </p>
                        <asp:Button ID="MovieButton6" runat="server" Text="Coming Soon..." CssClass="homeBtn"/>
                    </div>
                </li>
            </ul>
            <nav class='navHome'>
                <ion-icon class='btn prev' name="arrow-back-outline"></ion-icon>
                <ion-icon class='btn next' name="arrow-forward-outline"></ion-icon>
            </nav>
        </main>
        <script type="module" src="https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.esm.js"></script>
        <script nomodule src="https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <script type="text/javascript">
            const slider = document.querySelector('.slider');

            function activate(e) {
                const items = document.querySelectorAll('.item');
                e.target.matches('.next') && slider.append(items[0])
                e.target.matches('.prev') && slider.prepend(items[items.length - 1]);
            }

            document.addEventListener('click', activate, false);
        </script>

    </body>
</asp:Content>


