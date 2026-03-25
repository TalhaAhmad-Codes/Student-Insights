from pydantic import BaseModel
from datetime import datetime
from uuid import UUID


# API DTO (auto-convert to dict for API calls)
class ApiDTO(BaseModel):
    def to_dict(self):
        return self.model_dump(exclude_none=True)


# Base DTO (ID only)
class BaseDTO(ApiDTO):
    id: UUID


# Auditable DTO (Created Date)
class BaseAuditableDTO(BaseDTO):
    createdAt: datetime


# Creator DTO (Created By User)
class BaseCreatorResponseDTO(BaseAuditableDTO):
    creatorUserId: UUID

# Creator DTO (Creating by UseR)
class BaseCreatorCreateDTO:
    creatorUserId: UUID
