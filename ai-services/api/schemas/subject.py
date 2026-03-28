from api.schemas.common.base import BaseDTO, BaseCreatorResponseDTO
from api.schemas.common.filter import BaseCreatorFilterDTO
from pydantic import BaseModel
from uuid import UUID

# Subject - To get response
class SubjectResponseDTO(BaseCreatorResponseDTO):
    name: str

# Subject - To create
class SubjectCreateDTO(BaseModel):
    creatorUserId: UUID | str
    name: str

# Subject - To filter
class SubjectFilterDTO(BaseCreatorFilterDTO):
    name: str | None = None

# Subject - To update
class SubjectUpdateDTO(BaseDTO):
    name: str
