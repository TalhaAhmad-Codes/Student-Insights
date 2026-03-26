from api.schemas.user import UserCreateDTO, UserResponseDTO
from api.mappers.auto_mapper import AutoMapper
from api.client import ApiClient
from api.routes import User
from uuid import UUID

api = ApiClient()


class UserService:
    @staticmethod
    def get_all() -> list[UserResponseDTO]:
        res = api.get(User.Get.all())
        return AutoMapper.to_dto(UserResponseDTO, res, True)

    @staticmethod
    def get_by_id(_id: UUID | str) -> UserResponseDTO:
        res = api.get(User.Get.by_id(_id))
        return AutoMapper.to_dto(UserResponseDTO, res)

    @staticmethod
    def create(dto: UserCreateDTO) -> UserResponseDTO:
        res = api.post(User.Post.create(), dto)
        return AutoMapper.to_dto(UserResponseDTO, res)

    @staticmethod
    def create_bulk(data: list[UserCreateDTO]):
        return api.post(User.Post.create_bulk(), data)
