from fastapi import APIRouter
from api.services.api_client import ApiClient

router = APIRouter()
api = ApiClient()


@router.post("/seed")
def seed_data():
    pass
