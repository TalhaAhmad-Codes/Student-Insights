from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO, BaseCreatorCreateDTO
from api.schemas.common.filter import BaseCreatorFilterDTO
from pydantic import BaseModel
from uuid import UUID

# Department - To get response
class DepartmentResponseDTO(BaseCreatorResponseDTO):
    name: str
    totalStudents: int

# Department - To create
class DepartmentCreateDTO(BaseModel):
    creatorUserId: UUID | str
    name: str

# Department - To filter
class DepartmentFilterDTO(BaseCreatorFilterDTO):
    name: str | None = None

# Department - To update
class DepartmentUpdateDTO(BaseDTO):
    name: str
