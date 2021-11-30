package com.dryupin.warehouse.repo;

import com.dryupin.warehouse.models.Component;
import com.dryupin.warehouse.models.Transaction;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

public interface TransactionRepository extends CrudRepository<Transaction, Long> {
    @Query(value = "SELECT * FROM transaction, component, staff WHERE component_id = component.id AND staff_id = staff.id",
            nativeQuery = true)
    Iterable<Transaction> GetAll();
}