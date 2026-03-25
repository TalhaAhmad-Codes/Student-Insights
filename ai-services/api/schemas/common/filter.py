from api.schemas.common.base import ApiDTO
from uuid import UUID


class BaseFilterDTO(ApiDTO):
    page: int = 1
    pageSize: int = 10


class BaseCreatorFilterDTO(BaseFilterDTO):
    creatorUserId: UUID | None = None
