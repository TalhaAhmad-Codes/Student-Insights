from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO, BaseCreatorCreateDTO, UUID
from api.schemas.common.filter import BaseCreatorFilterDTO
from misc.enums import ExamType, ExamStatus
from datetime import date

# Student Exam Logs - To get response
class StudentExamLogsResponseDTO(BaseCreatorResponseDTO):
    obtainedMarks: int
    status: ExamStatus
    note: str | None
    studentId: UUID
    examId: UUID

# Student Exam Logs - To get detailed response
class StudentExamLogsDetailedResponseDTO(StudentExamLogsResponseDTO):
    studentName: str
    rollNumber: int
    studentDepartmentName: str
    percentage: float

    examType: ExamType
    examDepartmentName: str
    totalMarks: int
    dateOfConduct: date

# Student Exam Logs - To create
class StudentExamLogsCreateDTO(BaseCreatorCreateDTO):
    obtainedMarks: int
    note: str | None
    status: ExamStatus
    studentId: UUID
    examId: UUID

# Student Exam Logs - To filter
class StudentExamLogsDTO(BaseCreatorFilterDTO):
    minObtainedMarks: int | None = None
    maxObtainedMarks: int | None = None
    status: ExamStatus | None = None
    studentId: UUID | None = None
    examId: UUID | None = None

# Student Exam Logs - To update
class StudentExamLogsUpdateDTO(BaseDTO):
    obtainedMarks: int
    note: str | None
    status: ExamStatus
    studentId: UUID
    examId: UUID
