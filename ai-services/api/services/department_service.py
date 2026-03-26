from api.schemas.department import DepartmentCreateDTO, DepartmentResponseDTO
from api.mappers.auto_mapper import AutoMapper
from api.routes import Department
from api.client import ApiClient
from uuid import UUID

api = ApiClient()

class DepartmentService:
    @staticmethod
    def get_all() -> list[DepartmentResponseDTO]:
        """ Get all departments """
        res = api.get(Department.Get.all())
        return AutoMapper.to_dto(DepartmentResponseDTO, res, True)

    @staticmethod
    def get_by_id(_id: UUID | str) -> DepartmentResponseDTO:
        res = api.get(Department.Get.by_id(_id))
        return AutoMapper.to_dto(DepartmentResponseDTO, res)

    @staticmethod
    def create(dto: DepartmentCreateDTO) -> DepartmentResponseDTO:
        res = api.post(Department.Post.create(), dto)
        return AutoMapper.to_dto(DepartmentResponseDTO, res)

    @staticmethod
    def create_bulk(data: list):
        """ Create bulk department """
        return api.post(Department.Post.create_bulk(), data)
