from faker import Faker
from .base import BaseDto
from uuid import UUID

fk = Faker()

class UserCreateDto(BaseDto):
    profile_pic: list | None = None
    name: str = fk.name()
    email: str = fk.email(domain='gmail.com')
    password: str = fk.password(length=8, digits=True, lower_case=True)

class UserResponseDto(BaseDto):
    id: UUID
    profile_pic: list | None = None
    name: str
    email: str
