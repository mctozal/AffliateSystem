Affiliate System for Company Y 🚀


🌟 Overview
Welcome to the Affiliate System built for Company Y! This project delivers a secure, scalable website with a simple affiliate system, featuring login and registration pages tailored to specific requirements. It’s designed to empower users with role-based access (Customer, Manager, Admin) while ensuring robust security against common threats.

Built with C# .NET Core, adhering to SOLID principles and Aspect-Oriented Programming (AOP), this system is both maintainable and future-proof.

✨ Features
🔐 Login Page
Robot Protection 🤖: CAPTCHA to block automated login attempts.
Rate Limiting ⏳: Temporarily blocks excessive requests.
IP Blocking 🚫: Locks out IPs after 10 failed attempts in a row.
Dashboard 📊: Displays user info (name, role) post-login.
Roles: Customer, Manager, Admin.
Admin Summary 👑: Shows counts of Customers and Managers for Admins.
Security 🛡️:
Prevents XSS attacks across all sections.
Stops referral URL guessing with secure validation.
📝 Register Page
Registration Options:
Simple: Form-based signup as a Customer.
Referral: Signup via referral link as a Manager.
Logic:
No referral link → Customer role.
Valid referral link → Manager role.
Anti-Brute Force 🔒: Protects referral links from guessing attempts.
🛡️ Security Highlights
Feature	Implementation
Anti-Robot	CAPTCHA integration
Rate Limiting	Throttles excessive requests
IP Blocking	Blocks after 10 failed logins
XSS Prevention	Input sanitization everywhere
Referral Protection	Non-guessable codes + validation
🛠️ Tech Stack
Database: SQL Server or PostgreSQL
IDE: Visual Studio
Backend: C# with .NET Core
Design: SOLID principles + AOP
Frontend: Blazor (Server/WebAssembly)
📂 Project Structure
text

Collapse

Wrap


🚀 Getting Started
Prerequisites
.NET 9
Visual Studio
SQL Server
Git
Installation
Clone the Repo:
bash

Collapse

Wrap

Copy
git clone https://github.com/mctozal/AffiliateSystem.git
cd AffiliateSystem
Set Up the Database:
Edit appsettings.json 



Apply migrations:
bash

Collapse

Wrap

Copy
dotnet ef migrations add InitialCreate --project AffiliateSystem.Data
dotnet ef database update --project AffiliateSystem.Data
Install Dependencies:
bash

Collapse

Wrap

Copy
dotnet restore
Run the App:
bash

Collapse

Wrap

Copy
dotnet build
dotnet run --project AffiliateSystem.Web

🎮 Usage
Login: Go to /login, enter credentials, and access your dashboard.
Register:
Simple: /register → Customer role.
Referral: /register?ref=uniqueCode → Manager role.
Admin View: See user stats if logged in as Admin.
🧠 Development Notes
SOLID: Clean, modular code with single-responsibility classes.
AOP: Cross-cutting concerns (logging, security) handled elegantly.
Security: Input validation and sanitization at every layer.
🌱 Future Enhancements
✉️ Email verification for new users.
📈 Detailed analytics for Admins.
🤝 Contributing
Found a bug? Want to add a feature? Open an issue or submit a pull request! Please:

Follow the existing code style.
Add tests for new functionality.
📜 License
Proprietary software for Company Y. Unauthorized use or distribution is prohibited.