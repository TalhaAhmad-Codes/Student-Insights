# Student Insights

A student performance tracking and prediction system built using **ASP.NET Web API**, **WPF**, **SQL Server**, and **Python ML services**.

## Overview

**Student Insights** is a mini system designed to help teachers track and analyze student performance across exams and tests. The system stores performance history and uses machine learning to analyze trends and predict future scores.

> This project is built primarily for learning and portfolio purposes.

## Architecture

The system consists of four main components:

**Frontend**
- WPF Desktop Application
- CRUD operations for students, departments, and exam logs
- Sends requests to backend APIs

**Backend**
- ASP.NET Web API
- Handles business logic
- Manages database operations
- Provides APIs for both frontend and AI services

**Database**
- SQL Server
- Stores students, departments, exams, and performance logs

**AI Services**
- FastAPI
- NumPy, Pandas, Scikit-Learn
- Performs data analysis and score prediction

## Tech Stack

Frontend
- WPF (.NET)

Backend
- ASP.NET Web API

Database
- SQL Server

AI Services
- Python
- NumPy
- Pandas
- Scikit-Learn
- FastAPI

## Goals of This Project

- Practice backend architecture with .NET
- Integrate Python ML services with a .NET backend
- Build a full desktop + API + AI system
- Create a strong portfolio project

## Future Features

- Student performance analytics
- Score prediction using ML models
- Trend visualization
- Department level statistics
