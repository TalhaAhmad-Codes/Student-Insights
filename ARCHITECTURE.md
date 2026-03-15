
# Student Insight - Architecture

This project follows multi-service architecture where different high-level components communicate each other. It usually falls in a 3-tier architecture category. The high-level components are:

1. Frontend
2. Backend
3. AI Service - *Deals with the backend*
4. Database

The root architecture of this project is:
```
StudentInsight
│
├── frontend
│   └── StudentInsight/
│
├── backend
│   └── StudentInsight/
│
├── ai-service
│   └── StudentInsight/
│
├── docs
│   └── diagrams/
│
├── scripts
│   └── sample-data/
│
├── .gitignore
├── LICENSE
├── ARCHITECTURE.md
└── README.md
```

| Folder     | Purpose                |
| ---------- | ---------------------- |
| **frontend**   | WPF desktop app        |
| **backend**    | ASP.NET API            |
| **ai-service** | Python ML service      |
| **docs**       | diagrams, architecture |
| **scripts**    | test data / utilities  |

---

## Frontend

This componenet is responsible for UI/UX and uses desktop technologies such as `.NET`, `WPF`, and `MVVM pattern`. It's architecture is based on:

```
StudentInsight
│
├── Views
│   ├── Students
│   │   ├── StudentListView.xaml
│   │   └── StudentFormView.xaml
│   │
│   ├── Departments
│   │   └── DepartmentView.xaml
│   │
│   └── Performance
│       └── PerformanceView.xaml
│
├── ViewModels
│   ├── StudentViewModel.cs
│   ├── DepartmentViewModel.cs
│   └── PerformanceViewModel.cs
│
├── Models
│   ├── StudentModel.cs
│   ├── DepartmentModel.cs
│   └── ExamLogModel.cs
│
├── Services
│   └── ApiService.cs
│
├── Helpers
│   └── RelayCommand.cs
│
├── Converters
│
├── Resources
│
├── App.xaml
└── MainWindow.xaml
```

---

## Backend

This componenet follows repository pattern and code-first approach by using technologies `ASP.NET Web APIs` and `Entity Framework`. It's architecture is based on:

```
StudentInsight
│
├── Controllers
│   ├── StudentsController.cs
│   ├── DepartmentsController.cs
│   └── PerformanceController.cs
│
├── Entities
│   ├── Student.cs
│   ├── Department.cs
│   └── ExamLog.cs
│
├── DTOs
│   ├── StudentDto.cs
│   ├── CreateStudentDto.cs
│   └── ExamLogDto.cs
│
├── Repositories
│   ├── Interfaces
│   │   ├── IStudentRepository.cs
│   │   └── IExamLogRepository.cs
│   │
│   └── Implementations
│       ├── StudentRepository.cs
│       └── ExamLogRepository.cs
│
├── Services
│   ├── StudentService.cs
│   └── PerformanceService.cs
│
├── Data
│   ├── StudentInsightDbContext.cs
│   └── Configurations
│       ├── StudentConfiguration.cs
│       └── ExamLogConfiguration.cs
│
├── Migrations
│
├── Clients
│   └── AiServiceClient.cs
│
├── Helpers
│   └── MappingProfile.cs
│
├── Program.cs
└── appsettings.json
```

---

## AI Service

This is responsible for all AI related tasks like data analysis and predictions. It's architecture is based on:

```
StudentInsight
│
├── api
│   ├── routes
│   │   ├── analysis.py
│   │   └── prediction.py
│   │
│   └── schemas
│       └── student_schema.py
│
├── services
│   ├── analysis_service.py
│   └── prediction_service.py
│
├── ml
│   ├── models
│   │   └── score_predictor.py
│   │
│   └── training
│       └── train_model.py
│
├── utils
│   └── data_processing.py
│
├── main.py
└── requirements.txt
```

---

## Diagrams

### Git WorkFlow

![git-flow-diagram](/docs/git-flow/git%20flow%20diagram.png)

### Architecture - Components Communication

![arch-comm-diagram](/docs/components-communication/components-communication.png)

---
