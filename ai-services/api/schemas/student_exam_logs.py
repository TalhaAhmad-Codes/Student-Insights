from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO, UUID
from api.schemas.common.filter import BaseCreatorFilterDTO
from misc.enums import ExamType, ExamStatus
from pydantic import BaseModel
from datetime import date

# Student Exam Logs - To get response
class StudentExamLogsResponseDTO(BaseCreatorResponseDTO):
    obtainedMarks: int
    status: ExamStatus
    note: str | None
    studentId: UUID | str
    examId: UUID | str

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
class StudentExamLogsCreateDTO(BaseModel):
    creatorUserId: UUID | str
    obtainedMarks: int
    note: str | None
    status: ExamStatus
    studentId: UUID | str
    examId: UUID | str

# Student Exam Logs - To filter
class StudentExamLogsDTO(BaseCreatorFilterDTO):
    minObtainedMarks: int | None = None
    maxObtainedMarks: int | None = None
    status: ExamStatus | None = None
    studentId: UUID | str | None = None
    examId: UUID | str | None = None

# Student Exam Logs - To update
class StudentExamLogsUpdateDTO(BaseDTO):
    obtainedMarks: int
    note: str | None
    status: ExamStatus
    studentId: UUID | str
    examId: UUID | str
