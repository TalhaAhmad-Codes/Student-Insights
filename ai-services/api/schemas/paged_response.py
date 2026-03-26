from typing import Generic, TypeVar, List
from pydantic import BaseModel

T = TypeVar("T")


class PagedResponse(BaseModel, Generic[T]):
    items: List[T]
    totalCount: int
