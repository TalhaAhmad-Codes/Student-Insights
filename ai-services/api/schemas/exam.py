from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO, BaseCreatorCreateDTO, UUID
from api.schemas.common.filter import BaseCreatorFilterDTO
from misc.enums import ExamType
from pydantic import BaseModel
from datetime import date

# Exam - To get response
class ExamResponseDTO(BaseCreatorResponseDTO):
    type: ExamType
    totalMarks: int
    totalStudentsEnrolled: int
    conductedDate: date
    departmentId: UUID | str

# Exam - To create
class ExamCreateDTO(BaseModel):
    creatorUserId: UUID | str
    type: ExamType
    totalMarks: int
    conductedDate: date | str
    departmentId: UUID | str

# Exam - To filter
class ExamFilterDTO(BaseCreatorFilterDTO):
    type: ExamType | None = None
    minTotalMarks: int | None = None
    maxTotalMarks: int | None = None
    fromConductedDate: date | None = None
    toConductedDate: date | None = None
    departmentId: UUID | str | None = None

# Exam - To create
class ExamUpdateDTO(BaseDTO):
    type: ExamType
    totalMarks: int
    conductedDate: date
    departmentId: UUID | str
