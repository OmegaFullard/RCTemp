<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Directions.aspx.cs" MasterPageFile="Site.Master" Inherits="RCTemp.Directions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .directions-container {
            max-width: 1200px;
            margin: 30px auto;
            padding: 20px;
            background: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .directions-header {
            text-align: center;
            color: #1e1e2f;
            margin-bottom: 30px;
            font-size: 32px;
            border-bottom: 3px solid #8035f0;
            padding-bottom: 15px;
        }

        .directions-content {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 30px;
            margin-bottom: 30px;
        }

        .directions-list {
            background: #f9f9f9;
            padding: 20px;
            border-radius: 8px;
            border-left: 4px solid #8035f0;
        }

        .directions-list h3 {
            color: #1e1e2f;
            margin-bottom: 20px;
            font-size: 24px;
        }

        .direction-step {
            display: flex;
            align-items: start;
            margin-bottom: 15px;
            padding: 10px;
            background: white;
            border-radius: 5px;
            transition: transform 0.2s;
        }

        .direction-step:hover {
            transform: translateX(5px);
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .step-number {
            background: #8035f0;
            color: white;
            width: 30px;
            height: 30px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            font-weight: bold;
            margin-right: 15px;
            flex-shrink: 0;
        }

        .step-text {
            color: #333;
            line-height: 1.6;
        }

        .map-container {
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }

        .map-container iframe {
            width: 100%;
            height: 500px;
            border: none;
        }

        .info-cards {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 20px;
            margin-top: 30px;
        }

        .info-card {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
            border-radius: 8px;
            color: white;
            text-align: center;
        }

        .info-card i {
            font-size: 32px;
            margin-bottom: 10px;
        }

        .info-card h4 {
            margin: 10px 0;
            font-size: 18px;
        }

        .info-card p {
            margin: 5px 0;
            font-size: 14px;
        }

        .route-selector {
            margin-bottom: 20px;
            text-align: center;
        }

        .route-btn {
            background: #8035f0;
            color: white;
            border: none;
            padding: 10px 20px;
            margin: 0 5px;
            border-radius: 5px;
            cursor: pointer;
            font-weight: bold;
            transition: background 0.3s;
        }

        .route-btn:hover {
            background: #6a2bc7;
        }

        .route-btn.active {
            background: #1e1e2f;
        }

        @media (max-width: 768px) {
            .directions-content {
                grid-template-columns: 1fr;
            }
        }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="directions-container">
        <h1 class="directions-header">🗺️ Directions to Our Office</h1>

        <div class="route-selector">
            <button class="route-btn active" onclick="changeRoute('driving')">
                <i class="fas fa-car"></i> Driving
            </button>
            <button class="route-btn" onclick="changeRoute('transit')">
                <i class="fas fa-bus"></i> Public Transit
            </button>
            <button class="route-btn" onclick="changeRoute('walking')">
                <i class="fas fa-walking"></i> Walking
            </button>
        </div>

        <div class="directions-content">
            <div class="directions-list">
                <h3><i class="fas fa-route"></i> Step-by-Step Directions</h3>
                
                <div class="direction-step">
                    <div class="step-number">1</div>
                    <div class="step-text">
                        <strong>Start at Philadelphia City Hall</strong><br />
                        Head east on Market St toward S Juniper St
                    </div>
                </div>

                <div class="direction-step">
                    <div class="step-number">2</div>
                    <div class="step-text">
                        <strong>Turn right onto S Broad St</strong><br />
                        Continue for 0.3 miles
                    </div>
                </div>

                <div class="direction-step">
                    <div class="step-number">3</div>
                    <div class="step-text">
                        <strong>Turn left onto Walnut St</strong><br />
                        Drive for 0.5 miles
                    </div>
                </div>

                <div class="direction-step">
                    <div class="step-number">4</div>
                    <div class="step-text">
                        <strong>Turn right onto S 15th St</strong><br />
                        Continue for 0.2 miles
                    </div>
                </div>

                <div class="direction-step">
                    <div class="step-number">5</div>
                    <div class="step-text">
                        <strong>Arrive at destination</strong><br />
                        Royal City Help Desk Center will be on your right
                    </div>
                </div>

                <div style="margin-top: 20px; padding: 15px; background: #fff3cd; border-radius: 5px; border-left: 4px solid #ffc107;">
                    <strong><i class="fas fa-info-circle"></i> Note:</strong> Parking is available in the building garage. Enter from Sansom St.
                </div>
            </div>

            <div class="map-container">
                <iframe id="mapFrame" 
                    src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d12234.543958929013!2d-75.16621169999999!3d39.94953124999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s39.57.09%2C75.10.14.8!5e0!3m2!1sen!2sus!4v1723056453703!5m2!1sen!2sus" 
                    allowfullscreen="" 
                    loading="lazy" 
                    referrerpolicy="no-referrer-when-downgrade">
                </iframe>
            </div>
        </div>

        <div class="info-cards">
            <div class="info-card">
                <i class="fas fa-map-marker-alt"></i>
                <h4>Address</h4>
                <p>1234 Market Street</p>
                <p>Philadelphia, PA 19107</p>
            </div>

            <div class="info-card">
                <i class="fas fa-clock"></i>
                <h4>Hours</h4>
                <p>Monday - Friday</p>
                <p>8:00 AM - 6:00 PM</p>
            </div>

            <div class="info-card">
                <i class="fas fa-phone"></i>
                <h4>Contact</h4>
                <p>Phone: (215) 555-0100</p>
                <p>Email: help@royalcity.com</p>
            </div>

            <div class="info-card">
                <i class="fas fa-parking"></i>
                <h4>Parking</h4>
                <p>Garage Available</p>
                <p>$5 for 2 hours</p>
            </div>
        </div>

        <div style="text-align: center; margin-top: 30px;">
            <a href="https://www.google.com/maps/dir/?api=1&destination=39.9495,-75.1662" 
               target="_blank" 
               class="route-btn" 
               style="display: inline-block; text-decoration: none;">
                <i class="fas fa-external-link-alt"></i> Open in Google Maps
            </a>
        </div>
    </div>

    <script>
        function changeRoute(mode) {
            // Remove active class from all buttons
            document.querySelectorAll('.route-btn').forEach(btn => {
                btn.classList.remove('active');
            });
            
            // Add active class to clicked button
            addEventListener.target.closest('.route-btn').classList.add('active');

            // Update map based on mode
            const mapFrame = document.getElementById('mapFrame');
            const baseUrl = 'https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d12234.543958929013!2d-75.16621169999999!3d39.94953124999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s39.57.09%2C75.10.14.8!5e0!3m2!1sen!2sus!4v1723056453703!5m2!1sen!2sus';
            
            // In a real implementation, you would change the map URL based on the mode
            console.log(`Changed route to: ${mode}`);
            
            // Update directions text based on mode
            updateDirections(mode);
        }

        function updateDirections(mode) {
            const directionsList = document.querySelector('.directions-list');
            let directionsHTML = '<h3><i class="fas fa-route"></i> Step-by-Step Directions</h3>';

            if (mode === 'driving') {
                directionsHTML += `
                    <div class="direction-step">
                        <div class="step-number">1</div>
                        <div class="step-text">
                            <strong>Start at Philadelphia City Hall</strong><br />
                            Head east on Market St toward S Juniper St
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">2</div>
                        <div class="step-text">
                            <strong>Turn right onto S Broad St</strong><br />
                            Continue for 0.3 miles
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">3</div>
                        <div class="step-text">
                            <strong>Turn left onto Walnut St</strong><br />
                            Drive for 0.5 miles
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">4</div>
                        <div class="step-text">
                            <strong>Turn right onto S 15th St</strong><br />
                            Continue for 0.2 miles
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">5</div>
                        <div class="step-text">
                            <strong>Arrive at destination</strong><br />
                            Royal City Help Desk Center will be on your right
                        </div>
                    </div>
                    <div style="margin-top: 20px; padding: 15px; background: #fff3cd; border-radius: 5px; border-left: 4px solid #ffc107;">
                        <strong><i class="fas fa-info-circle"></i> Note:</strong> Parking is available in the building garage. Enter from Sansom St.
                    </div>
                `;
            } else if (mode === 'transit') {
                directionsHTML += `
                    <div class="direction-step">
                        <div class="step-number">1</div>
                        <div class="step-text">
                            <strong>Take SEPTA Market-Frankford Line</strong><br />
                            Board at City Hall Station heading eastbound
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">2</div>
                        <div class="step-text">
                            <strong>Get off at 15th Street Station</strong><br />
                            Exit at Market Street
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">3</div>
                        <div class="step-text">
                            <strong>Walk south on 15th St</strong><br />
                            Continue for 2 blocks (0.2 miles)
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">4</div>
                        <div class="step-text">
                            <strong>Arrive at destination</strong><br />
                            Royal City Help Desk Center will be on your right
                        </div>
                    </div>
                    <div style="margin-top: 20px; padding: 15px; background: #d1ecf1; border-radius: 5px; border-left: 4px solid #0dcaf0;">
                        <strong><i class="fas fa-info-circle"></i> Transit Info:</strong> Total journey time approximately 15 minutes. Fare: $2.50
                    </div>
                `;
            } else if (mode === 'walking') {
                directionsHTML += `
                    <div class="direction-step">
                        <div class="step-number">1</div>
                        <div class="step-text">
                            <strong>Start at Philadelphia City Hall</strong><br />
                            Head east on Market St
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">2</div>
                        <div class="step-text">
                            <strong>Continue on Market St</strong><br />
                            Walk for 0.8 miles (approximately 16 minutes)
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">3</div>
                        <div class="step-text">
                            <strong>Turn right onto S 15th St</strong><br />
                            Walk for 0.2 miles (4 minutes)
                        </div>
                    </div>
                    <div class="direction-step">
                        <div class="step-number">4</div>
                        <div class="step-text">
                            <strong>Arrive at destination</strong><br />
                            Royal City Help Desk Center will be on your right
                        </div>
                    </div>
                    <div style="margin-top: 20px; padding: 15px; background: #d1f2eb; border-radius: 5px; border-left: 4px solid #20c997;">
                        <strong><i class="fas fa-info-circle"></i> Walking Time:</strong> Approximately 20 minutes (1 mile total)
                    </div>
                `;
            }

            directionsList.innerHTML = directionsHTML;
        }
    </script>
</asp:Content>
