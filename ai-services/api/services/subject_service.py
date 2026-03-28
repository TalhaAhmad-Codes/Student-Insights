from api.schemas.subject import SubjectCreateDTO, SubjectResponseDTO
from api.mappers.auto_mapper import AutoMapper
from api.routes import Subject
from api.client import ApiClient
from uuid import UUID

api = ApiClient()

class SubjectService:
    @staticmethod
    def get_all() -> list[SubjectResponseDTO]:
        """ Get all departments """
        res = api.get(Subject.Get.all())
        return AutoMapper.to_dto(SubjectResponseDTO, res, True)

    @staticmethod
    def get_by_id(_id: UUID | str) -> SubjectResponseDTO:
        res = api.get(Subject.Get.by_id(_id))
        return AutoMapper.to_dto(SubjectResponseDTO, res)

    @staticmethod
    def create(dto: SubjectCreateDTO) -> SubjectResponseDTO:
        res = api.post(Subject.Post.create(), dto)
        return AutoMapper.to_dto(SubjectResponseDTO, res)

    @staticmethod
    def create_bulk(data: list):
        """ Create bulk department """
        return api.post(Subject.Post.create_bulk(), data)
