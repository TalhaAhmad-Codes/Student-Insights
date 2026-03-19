from pydantic import EmailStr
from .base import BaseDto
from uuid import UUID


class UserCreateDto(BaseDto):
    profile_pic: list | None = None
    name: str
    email: EmailStr
    password: str


class UserResponseDto(BaseDto):
    id: UUID
    name: str
    email: EmailStr
