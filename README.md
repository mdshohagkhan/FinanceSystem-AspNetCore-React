<h1 align="center">💰 Finance Management System (FMS)</h1>

<p align="center">
  <strong>A secure, modern, and scalable platform to manage finances with ease.</strong><br/>
  <em>Powered by ASP.NET Core (.NET 7/8) + React 18 (Vite)</em>
</p>

<div align="center">
  <img src="https://img.shields.io/badge/Backend-ASP.NET_Core-blue?style=flat-square" />
  <img src="https://img.shields.io/badge/Frontend-React_18-blueviolet?style=flat-square" />
  <img src="https://img.shields.io/badge/Database-SQL_Server-success?style=flat-square" />
  <img src="https://img.shields.io/badge/License-MIT-lightgrey?style=flat-square" />
</div>

---

## 🌈 Why FMS?

> _"Financial control shouldn't be a hassle."_

Traditional finance systems are often:

- 🐢 Slow
- 🔓 Insecure
- ❌ Hard to scale

**FMS solves these problems with:**

- ⚡ Ultra-fast Frontend (React + Vite)
- 🔐 Secure Backend (ASP.NET Core with RBAC)
- 📊 Real-time Dashboards & Reporting
- 🧱 Clean, Scalable Architecture
- 🚀 Production-ready Deployment

---

## 🧠 Tech Stack

| Layer      | Tech Used                         |
|------------|------------------------------------|
| 💻 Frontend | React 18, Vite, Tailwind CSS       |
| 🔙 Backend  | ASP.NET Core (.NET 7/8), C#        |
| 🗄️ Database | SQL Server                        |
| 🔐 Auth     | ASP.NET Identity + JWT Token       |
| 🔧 Tools    | MSBuild, Vite, .NET CLI            |

---

## 📁 Project Structure

FinanceSystem-AspNetCore-React/
├── FinancialManagementSystems.sln # Solution File
├── FinancialManagementSystems/ # ASP.NET Core Project
├── frontend/ # React (Vite) App
└── vite.config.js # Vite Config

yaml
Copy code

---

## 🚀 Getting Started

### <h3 1️⃣ Clone the Repo></h3>

```bash
git clone https://github.com/mdshohagkhan/FinanceSystem-AspNetCore-React.git
cd FinanceSystem-AspNetCore-React
2️⃣ Backend Setup
bash
Copy code
cd FinancialManagementSystems
dotnet restore
dotnet run
# 🟢 Runs at: https://localhost:5001
3️⃣ Frontend Setup
bash
Copy code
cd frontend
npm install
npm run dev
# 🟢 Runs at: http://localhost:5173
🔑 Demo Credentials
Role	Username	Password
Admin	admin	admin123

🌟 Core Features
🧑‍💼 Role-Based Access – Admin, Manager, User

💳 Manage Accounts, Transactions, Expenses

📊 Real-time Financial Reporting

🔗 Clean REST API Integration

🧱 Modular & Scalable Architecture

⚙️ Environment Variables
🔧 Backend (.env or appsettings.json)
ini
Copy code
ConnectionStrings__DefaultConnection=Your-SQLServer-Connection-String
🌐 Frontend (.env)
bash
Copy code
VITE_API_URL=http://localhost:5000/api
📦 Build & Deployment
🔨 Backend
bash
Copy code
dotnet publish -c Release
🌐 Frontend
bash
Copy code
npm run build
✅ Easily deploy to Azure, Vercel, or Docker.

📸 Screenshots


🔐 Login Page

📊 Dashboard

🧾 Account Summary

### 📺 Project Demo (YouTube)



🔗 Watch on YouTube: https://youtu.be/XmQAgUvcJqw


🤝 Contributing
Fork the repo

Create a new branch: feature/your-feature

Commit your changes

Push and open a Pull Request 🎉

📜 License
Licensed under the MIT License — free to use and improve!

<p align="center">✨ Built with ❤️ by <a href="https://github.com/mdshohagkhan">Shohag Miah</a> ✨</p> ```
