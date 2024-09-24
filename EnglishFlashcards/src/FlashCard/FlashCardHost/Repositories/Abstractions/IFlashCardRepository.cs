﻿namespace FlashCard.Host.Repositories.Abstractions;

public interface IFlashCardRepository
{
    Task<FlashCardDto> GetFlashCardById(int id);
    Task<FlashCardDto> GetRandomFlashCard();
    Task<int> AddFlashCard(FlashCardModel model);
    Task<int> UpdateFlashCardStatus(int flashCardId, int statusId);
    Task<int> UpdateFlashCard(FlashCardModel model);
    Task<bool> DeleteFlashCard(int id);
}