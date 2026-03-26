from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO, BaseCreatorCreateDTO, UUID
from api.schemas.common.filter import BaseCreatorFilterDTO
from datetime import date


# Student - To get response
class StudentResponseDTO(BaseCreatorResponseDTO):
    studentName: str
    fatherName: str
    rollNumber: int
    dateOfBirth: date
    departmentId: UUID | str

# Student - To create
class StudentCreateDTO(BaseCreatorCreateDTO):
    studentName: str
    fatherName: str
    rollNumber: int
    dateOfBirth: date
    departmentId: UUID | str

# Student - To filter
class StudentFilterDTO(BaseCreatorFilterDTO):
    fromRollNumber: int | None = None
    toRollNumber: int | None = None
    dateOfBirth: date | None = None
    departmentId: UUID | str | None = None

# Student - To update
class StudentUpdateDTO(BaseDTO):
    studentName: str
    fatherName: str
    rollNumber: int
    dateOfBirth: date
    departmentId: UUID | str
