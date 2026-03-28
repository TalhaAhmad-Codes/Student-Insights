from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO, UUID
from api.schemas.common.filter import BaseCreatorFilterDTO
from pydantic import BaseModel
from datetime import date

# Student - To get response
class StudentResponseDTO(BaseCreatorResponseDTO):
    studentName: str
    rollNumber: int
    dateOfBirth: date

# Student - To create
class StudentCreateDTO(BaseModel):
    creatorUserId: UUID | str
    studentName: str
    rollNumber: int
    dateOfBirth: date

# Student - To filter
class StudentFilterDTO(BaseCreatorFilterDTO):
    fromRollNumber: int | None = None
    toRollNumber: int | None = None
    dateOfBirth: date | None = None

# Student - To update
class StudentUpdateDTO(BaseDTO):
    studentName: str
    rollNumber: int
    dateOfBirth: date
