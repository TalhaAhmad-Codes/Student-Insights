from .dummy_data import departments
from .base import BaseDto
from random import sample
from uuid import UUID


class DepartmentCreateDto(BaseDto):
    name: str = ''.join(sample(departments, 1))

class UserResponseDto(BaseDto):
    id: UUID
    name: str
